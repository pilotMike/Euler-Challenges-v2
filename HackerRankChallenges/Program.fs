// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.


namespace HackerRankChallenges
    open System
//    open System.Diagnostics

    module Challenge =
        open System.Text

        type IChallengeSeq<'a> =
            abstract member Run : seq<'a>

        let benchmark f =
            let sw = System.Diagnostics.Stopwatch.StartNew()
            f() 
            sw.Stop()
//            ignore (printfn "%d" sw.ElapsedMilliseconds)
        
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

        type Challenge() =

            [<EntryPoint>]
            static let main argv = 
//                let input = Console.ReadLine()
//                let input = Data.StringCompression
////                let input = "2\n0.0000\n1.0000"
//                let prog = StringCompression(input)
//                let run = fun() ->
//                    let output = (prog :> IChallengeSeq<'a>).Run
//                    for o in output do
//                        ignore (printfn "%s" (o.ToString()))
                
                let run = fun ()->
                            let a = PrefixCompression'
                            for r in a do
                                Console.WriteLine(r)

                benchmark (run)
                ignore (Console.ReadLine())
//                Console.ReadLine()
                0 // return an integer exit code
