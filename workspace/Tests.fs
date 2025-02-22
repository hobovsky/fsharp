﻿module OddOrEvenTests

open OddOrEvenKata
open Preloaded

open NUnit.Framework

[<Test>]
let TestZero_TopLevelTest () =
    Assert.AreEqual(Answer.Even, oddOrEven 0)

[<TestFixture>]
type FixedTest() =

    [<Test>]
    member this.TestOne() =
        Assert.AreEqual(Answer.Odd, oddOrEven 1)

    [<Test>]
    member this.TestFail_NoCustomMessage() =
        Assert.AreEqual(Answer.Odd, oddOrEven 42)

    [<Test>]
    member this.TestFail_CustomMessage() =
        Assert.AreEqual(Answer.Odd, oddOrEven 42, "Incorrect answer for n={0}", 42)

    [<Test>]
    member this.TestCrash() =
        let s = null:string
        printf "Name: %s" (s.ToUpper())
        Assert.AreEqual(Answer.Odd, oddOrEven 42, "Incorrect answer for n={0}", 42)

    [<Test>]
    member this.TestPrint() =
        printf "Value: %d" 42
        Assert.AreEqual(Answer.Odd, oddOrEven 42, "Incorrect answer for n={0}", 42)

    [<Test>]
    member this.TestNegativeOdd ([<Values(-1, -3, -1001)>] n ) =
        Assert.AreEqual(Answer.Odd, oddOrEven n)

    [<TestCase(-2)>]
    [<TestCase(-42)>]
    [<TestCase(-1024)>]
    member this.TestNegativeEven n =
        Assert.AreEqual(Answer.Even, oddOrEven n)
