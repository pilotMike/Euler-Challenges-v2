
module ChallengesAsFunctions

open System

let PrefixCompression (textA:string) (textB:string) : seq<string> =
    let rec commonPrefix (a:string) (b:string) (i:int) : int =
        if i >= a.Length || i >= b.Length then
            i
        elif a.[i] = b.[i] then
            commonPrefix a b (i+1)
        else
            i
    let index = commonPrefix textA textB 0
    let formatString i (s:string) =
        let s = s.Substring(i)
        s.Length.ToString() + " " + s

    seq {
        yield formatString 0 (textA.Substring(0, index))
        yield formatString index textA
        yield formatString index textB
    }

let PrefixCompression' : seq<string> =
    let textA = Console.ReadLine()
    let textB = Console.ReadLine()
    seq {yield! PrefixCompression textA textB}