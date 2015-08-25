// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.


namespace HackerRankChallenges
    open System
    open System.Diagnostics

    module Challenge =
        open System.Text

        type IChallengeSeq<'a> =
            abstract member Run : seq<'a>

        type StringCompression(input:string) =
            interface IChallengeSeq<string> with
                member this.Run =
                    let sbuilder = StringBuilder()
                    let rec compress (sb:StringBuilder) (text:string) (position) =
                        if position = text.Length then sb.ToString()
                        else
                            let currentChar = text.[position]
                            let count = text |> Seq.skip position |> Seq.takeWhile (fun s -> s = currentChar) |> Seq.length
                            let newlyCompressed = if count = 1 then currentChar.ToString() else currentChar.ToString() + count.ToString()
                            compress (sb.Append(newlyCompressed)) text (count + position)
                    let result = compress sbuilder input 0
                    [result] |> List.toSeq

//            let RunAgain = 
//                let rec compress (compressed:seq<char>) (remainingText:seq<char>) =
//                    if not remainingText |> Seq.empty then compressed
//                    else

// c# 
        let benchmark f =
            let sw = System.Diagnostics.Stopwatch.StartNew()
            f() 
            sw.Stop()
            ignore (printfn "%d" sw.ElapsedMilliseconds)

        let GetSplit input:string =
            let procs = System.Environment.ProcessorCount

            let rec charsEqual input referencePoint index moveIndex : int=
                if input.[referencePoint] <> input.[index] then index
                else
                    charsEqual input referencePoint moveIndex

            if input.Length < 1000 then yield input
            else
                let prependCount = 0
                let appendCount = 0

                let rec divide text moveStartPoint sectionNumber =
                    let stopPosition = text.Length / sectionNumber
                    let c = text.[stopPosition]
                    let stopPoint = charsEqual text stopPosition 0 (fun i -> i + 1)
                    yield text.Substring()
                    yield! seq {divide text (stopPoint - stopPosition) (sectionNumber + 1)}
                yield! (divide input 0 0)


        open System.Text

        type StringCompresion1(input:string) =
            let partitionSize = 5000
            let rec divide (text:string) (index:int) : seq<string> = 
                seq {
                if partitionSize * index < text.Length then
                    yield text.Substring(partitionSize * index, partitionSize)
                else
                    yield! (divide text (index + 1))
                }

            let parts = divide input 0

            let compress1 (text:string) : string =
                let sbuilder = StringBuilder()
                let rec compress (sb:StringBuilder) (text:string) pos =
                    if pos = text.Length then sb.ToString()
                    else
                        let currentChar = text.[pos]
                        let count = text |> Seq.skip pos |> Seq.takeWhile (fun c -> c = currentChar) |> Seq.length
                        if count = 1 then ignore (sb.Append(currentChar))
                        else ignore (sb.Append(currentChar.ToString() + count.ToString()))
                        compress sb text (count + pos)
                let result = compress sbuilder input 0
                result
              
            
            let joinStrings (s1:string) (s2:string) : string=
                // if the end of s1 is a number, check to see if s2 is the same character, then add their values
                let isNumber c = c >= '0' && c <= '9'
                let s1Last = s1.[s1.Length - 1]

                if isNumber s1Last then
                    let s1Char = s1.[s1.Length - 2]
                    let s2Char = s2.[0]
                    if s1Char <> s2Char then
                        s1 + s2
                    else
                        let s1Val = System.Int32.Parse (s1Last.ToString())
                        let s2SecondPosition = s2.[1]
                        if isNumber s2SecondPosition then
                            let finalVal = (System.Int32.Parse (s1Last.ToString())) + (System.Int32.Parse (s2SecondPosition.ToString()))
                            let newS1 = (s1.Substring (0, (s1.Length - 1))) + (finalVal.ToString())
                            let newS2 = s2.Substring 2
                            newS1 + newS2
                        else
                            let finalVal = (System.Int32.Parse(s1Last.ToString())) + 1
                            let newS1 = s1.Substring(0, (s1.Length - 1)) + finalVal.ToString()
                            newS1 + s2
                else
                    s1 + s2    
               
            let joinParts strings =
                let sb = StringBuilder()
                let windowed = strings |> Seq.windowed 2
                windowed |> (a, b) -> joinStrings a b|> sb.Append
                sb.ToString()
                    
            let Run =
                let compressedParts = 
                    Async.Parallel [for p in parts -> async {return (compress1 p)}] 
                    |> Async.RunSynchronously

                let result = compressedParts |> Seq.fold (fun (acc:string) (current:string) :string -> joinStrings acc current)
                result


                
                               


    
        type Challenge() =

            [<EntryPoint>]
            static let main argv = 
//                let input = Console.ReadLine()
                let input = Data.StringCompression
//                let input = "2\n0.0000\n1.0000"
                let prog = StringCompression(input)
                let run = fun() ->
                    let output = (prog :> IChallengeSeq<'a>).Run
                    for o in output do
                        ignore (printfn "%s" (o.ToString()))
                
                benchmark run
                let procs = System.Environment.ProcessorCount * 3 / 4
                let parts = GetSplit input procs

//                Console.ReadLine()
                0 // return an integer exit code
