//
namespace EnumeratorTests
//
//open FsUnit
//open FsCheck
//open NUnit.Framework
//open Swensen.Unquote
//open EulerTools_FSharp
//open NUnitRunner
//
//[<TestFixture>]
//type EnumeratorTests() =
//    [<TestCase>]
//    member x.primes_enumerator_enumerates() =
//        let e = PrimesEnumerator()
//        let result = e.Primes() |> Seq.take 5
//        result |> should equal [3;5;7;11;13]
//        