#light
open System
open Microsoft.FSharp.Math
open System.Drawing
open System.Numerics
open System.Windows.Forms
let rec IsInMan_Br_Set(count, z, c, iter) =
    if (Complex.Abs(z) < 2.0) && (count < iter) then
        IsInMan_Br_Set((count+1), ((z * z) + c), c, iter)
    else count
let scal_Fact s = s * 1.0 / 200.0
let decart_syst_compl (x, y, s, cur_x, cur_y) =
    let fx = (x-200.0)/(100.0*s) + cur_x
    let fy = -(y-200.0)/(100.0*s) + cur_y
    Complex(fx,fy)
let colorize c =
      let r = (4 * c) % 100
      let g = (6 * c) % 200
      let b = (8 * c) % 255
      Color.FromArgb(r,g,b)
let createImage (s, mx, my, iter) =
    let image = new Bitmap(400, 400)
    for x = 0 to image.Width - 1 do
        for y = 0 to image.Height - 1 do
            let count = IsInMan_Br_Set(0, Complex.Zero, (decart_syst_compl(float x,float y, s, mx, my)), iter)
            if count = iter then
                image.SetPixel(x,y, Color.Black)
            else
                image.SetPixel(x,y, colorize( count ) )
    image
let mutable image = createImage (1.0, -0.7 , 0.28, 100)
let tem = new Form() in
    tem.Paint.Add(fun e -> e.Graphics.DrawImage(image, 0, 0))
tem

tem.Size <- Size(400,400)
let pic_box = new PictureBox()
pic_box.Image <- image
pic_box.Size <- (Size(400,400))
tem.Controls.Add(pic_box)

let mutable scale = 1.0
let mutable speed = 1.0
let mutable acc_scale = 1.0

let timer = new System.Windows.Forms.Timer(Interval = 10)
timer.Tick.Add <| fun  _ ->
    image <- createImage(scale, -0.7, 0.28, 20 + int acc_scale)
    pic_box.Image <- image
    scale <- scale+speed
    if int scale % 10 = 0 then speed <- speed + 2.0
    acc_scale <- acc_scale + 3.0
    if scale >= 100.0 then
        timer.Stop()
        pic_box.Image <- image
        scale <- scale*2.0
        if int scale % 10 = 0 then speed<-speed*2.0
    acc_scale<-acc_scale+3.0
    if scale >= 100.0 then
        timer.Stop()
        pic_box.Image<-image
timer.Start()
do Application.Run(tem)
0 // return an integer exit code