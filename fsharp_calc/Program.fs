open System
open System.Diagnostics
   module fsharp_Calc = 
       type MaybeBuilder() =
              member this.Bind(m,f) = match m with
              | None -> None
              | Some x -> f x 
              member this.Return(x) = Some x
       let maybe = new MaybeBuilder()
       let DivideTry x y =
           if y = 0
           then None
           else Some(x/y)
       let Calculate x o y = 
                match o with
                 | "+" -> Some(x + y)
                 | "-" -> Some(x - y)
                 | "/" -> DivideTry x y
                 | "*" -> Some(x * y)
                 | _ -> None
       let Calculator x o y =
           maybe {
               let! result = Calculate x o y
               return result
           }
[<EntryPoint>]
let main argv =
   let sum_5_5 = fsharp_Calc.Calculator 5 "+" 5
   printf ("%A") sum_5_5
   0