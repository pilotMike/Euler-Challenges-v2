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

        let stringReductions s :string =
            let rec reduce (s:string) (n:int) (result:list<char>) :list<char> = 
                if n = s.Length then
                    result
                elif List.exists ((=)s.[n]) result then
                    reduce s (n+1) result
                else
                    reduce s (n+1) (s.[n] :: result)
    
            let result = reduce s 0 []
            List.rev result |> List.toArray |> fun (l) -> String.Join("", l)


        type Challenge() =
            [<EntryPoint>]
            static let main argv = 
                let result = stringReductions (Console.ReadLine())
                Console.WriteLine(result)

//                let run = fun ()->
//                            let a = PrefixCompression'
//                            for r in a do
//                                Console.WriteLine(r)
//
//                benchmark (run)
//                ignore (Console.ReadLine())
//                Console.ReadLine()
                0 // return an integer exit code