// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.


namespace HackerRankChallenges
    open System

    module Challenge =
    

//        type IChallenge<'T> =
//            abstract member Run : seq<'T>
//        type EvaluatingEtoX(input:string) =
//            let mutable count = 0
//            let mutable variables = []
//            do
//                let split = input.Split '\n' |> Array.map double
//                count <- int split.[0]
//                variables <- split |> Seq.skip 1 |> Seq.take count |> Seq.toList
//                // c# way: count = split.First(); variables = split.Skip(1).Take(count).ToList();
//    
//            interface IChallenge<string> with 
//                member this.Run = 
//                    let expand (n:double, i:int) = (pown n i) / (double)i
//                    // c# : variables.SelectMany((v, i) => Enumerable.Range(1, i).Select(r => expand(v, r))
////                    variables |> Seq.mapi 
////                                (fun i v -> seq { yield 1.0; yield! seq {for i in 1 .. i do yield expand (v, i)}})
////                              |> fun list -> Seq.collect list
////                              |> fun list -> Seq.sum list
////                              |> fun x -> x.ToString()
//                  // c# way: (variables.Select((v, i) => expand(v, i)).Sum() + 1).ToString();
////                    variables |> Seq.mapi (fun index v -> 
////                                    (Seq.init index) |> fun i -> expand v i
////                                                      |> fun s -> incr (Seq.sum s))
////                                                      |> fun x -> x.ToString
//
//                    let expandMath x = Math.Pow(Math.E, x) / (float)x
//                    let operate10times x = 
//                        seq { 2 .. 10} |> Seq.map (fun x -> expandMath (float x))
//                    let expand' x = 
//                        seq {1; x; yield! seq { 2 .. 10 } |> Seq.map (fun x -> operate10times) }
//
//                    variables |> Seq.map ((fun v -> expand' v).ToString)
        
        type Challenge() =

            [<EntryPoint>]
            static let main argv = 
//                let input = Console.ReadLine()
//                let input = "2\n0.0000\n1.0000"
//                let prog = EvaluatingEtoX(input)
//                let output = (prog :> IChallenge<'a>).Run
//                for o in output do
//                    printfn "%s" (o.ToString())

//                Console.ReadLine()
                0 // return an integer exit code
