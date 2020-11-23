// Learn more about F# at http://fsharp.org

open System
open System.Data
open System.Net.Http
open System.Threading
open System.Diagnostics.CodeAnalysis
open FSharp.Data

type Async_Maybe_Builder () =
    member this.Bind(x, f) =
        async {
            let! x' = x
            match x' with
            | Some s -> return! f s
            | None -> return None
            }
    member this.Return(x:'a option) = async{return x}
    
module Calculator =
    let Async_Maybe = new Async_Maybe_Builder()
    let private Create_Resp_Async resp =
        async {
            return match resp.StatusCode with
            | 404 -> None
            | 400 -> "Invalid operation" |> Some
            | 200 -> resp.Headers.["calc_result"]|>Some
            | _ -> None
        }
    let parse_isse (exprsn:string) =
        let n_expr = exprsn.Replace("*","%2A").Replace("/","%2F").Replace("+","%2B")
        n_expr
    let Request(url) =
            async{
                let! res = Http.AsyncRequestStream(url, silentHttpErrors=true)
                let res = res|>Some
                return res            
            }
    let Calc (exprsn:string) =
            Async_Maybe{
            let issue = exprsn |> parse_isse
            let url = "https://localhost:5001/?issue=" + issue
            let! resp = Request url(*async { Http.AsyncRequestStream(url, silentHttpErrors = true)  |> Some}*)
            let! result = Create_Resp_Async(resp)
            return result |> Some
            }|>Async.RunSynchronously
    
    let Calculate(expr)=
       let res = Calc(expr)
       match res with
       | Some x -> x
       | _ -> "Nope"
        
        
[<EntryPoint>]
let main argv =
    Console.WriteLine(Calculator.Calculate("5+5"))
    Console.ReadKey()
    0 // return an integer exit code
