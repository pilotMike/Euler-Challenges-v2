namespace Challenges
open System


type IChallenge<'T> =
    abstract member Run : 'T
type IChallengeSeq<'a> =
    abstract member Run : seq<'a>

type ArrayOfNElements(input:string) =
    let input = Int32.Parse input
    interface IChallenge<List<int>> with member this.Run = [1..input]

type Gcd(input:string) = 
    let input = input.Split(' ') |> Array.map Int32.Parse
    let rec GreatestCommonDivisor (x) (y) =
        if y = 0 then x
        else
            if x >= y then GreatestCommonDivisor y (x % y)
            else GreatestCommonDivisor x (y % x)

    interface IChallenge<string> with
        member this.Run = (GreatestCommonDivisor input.[0] input.[1]).ToString()

type Fib(input:string) =
    let c = Int32.Parse input

    let fibs = 
        (0,1) |> Seq.unfold (fun(n0,n1) ->
                                Some(n0, (n1, n0+n1)))

    interface IChallenge<int> with
        member this.Run = Seq.nth (c - 1) fibs

    
type EvaluatingEtoX(input:string) =
    let mutable count = 0
    let mutable variables = []
    do
        let split = input.Split '\n' |> Array.map int
        count <- split.[0]
        variables <- split |> Seq.skip 1 |> Seq.take count |> Seq.toList
        // c# way: count = split.First(); variables = split.Skip(1).Take(count).ToList();
    
    interface IChallenge<string> with 
        member this.Run = 
            let expand n i = (pown n i) / i
            variables |> Seq.mapi (fun i v -> expand v i) |> fun (list) -> (Seq.sum list) + 1|> fun x -> x.ToString()
          // c# way: (variables.Select((v, i) => expand(v, i)).Sum() + 1).ToString();

 
// type FractalTrees(input:string) =
//    let iterations = System.Int32.Parse input
//    let lineLength = 100
//
//    interface IChallenge<string> with
//        member this.Run =
            
type StringCompression(input:string) =
    interface IChallengeSeq<string> with
        member this.Run =
            let rec compress compressed (remainingText:string) =
                if remainingText.Length = 0 then compressed
                else
                    let currentChar = remainingText.[0]
                    let count = remainingText |> Seq.takeWhile (fun s -> s = currentChar) |> Seq.length
                    let newlyCompressed = if count = 1 then currentChar.ToString() else currentChar.ToString() + count.ToString()
                    compress (compressed + newlyCompressed) (remainingText.Substring(count))
            let result = compress "" input
            [result] |> List.toSeq
