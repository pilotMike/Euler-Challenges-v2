namespace EulerTools_FSharp
open EulerTools.Primes

//type PrimesEnumerator() =
//    static let primesCalc : PrimeCalculator = PrimeCalculator()
//
//    let isPrime x = PrimeCalculator.IsPrime x
//
//    let primeSeq = 
//        Seq.initInfinite (fun i -> i + 2)
//        |> Seq.filter isPrime 
//
//    member this.Primes() =
//        3 |> Seq.unfold(fun i -> Some(i, i + 2)) |> Seq.filter isPrime

//        seq { yield 3; yield! Seq.scan (+) 1  }

module Enumerators =
    let primes() =
       seq {yield 2; yield! seq { for n in 3 .. 2 .. System.Int32.MaxValue do if PrimeCalculator.IsPrime n then yield n}}

//module Challenges =
//    open Enumerators
//    let ConsecutivePrimeSum(limit:int) : int =
//        let primes = primes() |> Seq.cache |> Seq.takeWhile (fun p -> p < limit)
//
//        let getCount (primeSubset:seq<int>) :int = 
//            let mutable sum = 0
//            let count = primeSubset 
//                        |> Seq.takeWhile (fun prime -> 
//                                              sum <- sum + prime
//                                              PrimeCalculator.IsPrime(sum))
//                        |> Seq.length
//            count
//
//        let longestCount = seq {for p in primes do
//                                yield (getCount (primes |> Seq.skipWhile (fun prime -> prime < p))) } 
//                           |> Seq.max
//        longestCount
