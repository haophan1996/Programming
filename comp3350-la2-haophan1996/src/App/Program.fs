open wit.comp3350

let printRow row =
    "  " |> String.replicate (20-row) |> printf "%s"
    [0..row] |> List.iter (printf "%-3d " << la2.pascalsTriangle row)
    printfn ""

[<EntryPoint>]
let main args =
    if args.Length = 1 then
        let numRows = int args[0]
        [0..numRows] |> List.iter printRow
        0
    else
        printfn "Need to supply int argument"
        1
