namespace EulerTools_FSharp

open Enumerators
open EulerTools.Primes
open EulerTools.Numbers

module Challenges =
    let ConsecutivePrimeSum(limit:int) : int =
        let primes = primes() |> Seq.cache |> Seq.takeWhile (fun p -> p < limit)

        let getCount (primeSubset:seq<int>) :int = 
            let mutable sum = 0
            let count = primeSubset 
                        |> Seq.takeWhile (fun prime -> 
                                              sum <- sum + prime
                                              PrimeCalculator.IsPrime(sum))
                        |> Seq.length
            count

        let longestCount = seq {for p in primes do
                                yield (getCount (primes |> Seq.skipWhile (fun prime -> prime < p))) } 
                           |> Seq.max
        longestCount

    let ConsecutivePrimeSums(limit): int =
        let primesBelowLimit = primes() |> Seq.takeWhile (fun p -> p < limit) |> Seq.cache

        let sumWhile (seq:seq<int>) (predicate): sum:int*count:int =
            let enum = seq.GetEnumerator()
            enum.MoveNext() |> ignore
            let mutable sum = 0

            let rec loop x i = 
                if predicate(x) && enum.MoveNext() then
                    sum <- sum + x
                    loop enum.Current (i+1)
                else
                    (sum,i)
            loop (enum.Current) 0

        let consecutiveLength x = primesBelowLimit |> Seq.skipWhile (fun p -> p <= x)
                                  |> Seq.map (fun s -> sumWhile primesBelowLimit (fun v -> v < limit))
                                  |> Seq.where (fun (sum, _) -> (Seq.contains sum primesBelowLimit))
                                  |> Seq.maxBy (fun (_,count) -> count)
                                  |> (fun (sum,_) -> sum)

        primesBelowLimit 
            |> Seq.map consecutiveLength 
            |> Seq.max


    let PermutedMultiples_58 =
        Seq.unfold (fun acc -> Some(acc, acc + 1)) 1
        |> Seq.filter (fun n ->
                [2..6] |> List.map (fun x -> x * n) |> List.forall (fun x -> DigitHelper.ArePermutations(x n)))
        |> Seq.head