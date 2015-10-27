
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

let StringReductions =
    let s = Console.ReadLine()
    let rec reduce (s:string) (n:int) (result:string) :string = 
        if n = s.Length then
            result
        elif String.exists ((=)s.[n]) result then
            reduce s (n+1) result
        else
            reduce s (n+1) (result + s.[n].ToString())
    
    let result = reduce s 0 ""
    result

open HelperFunctions
let SumsOfPowers x n =
    
    let limit = int (Math.Sqrt(float x))
    let powers = [1..limit] |> List.map (fun a -> (a*n))

    let getTotals (permutations:List<List<int>>) (target:int) : seq<int> =
        seq {for permutation in permutations do
                yield (sumUntil permutation target )}

    let permutations = getRotations powers //List<List<int>>
    let result = (getTotals permutations) // Seq<int>
                    |> Seq.where (fun a -> a = x) 
                    |> Seq.length
    result

let SumsOfPowersProg = 
    let x = Int32.Parse(Console.ReadLine())
    let n = Int32.Parse(Console.ReadLine())
    SumsOfPowers x n