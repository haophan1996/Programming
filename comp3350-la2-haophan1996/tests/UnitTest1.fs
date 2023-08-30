namespace wit.comp3350

open NUnit.Framework
open wit.comp3350.la2

module TestSyntax =
    [<Test>]
    let testAddPair () =
        let actual = addPair (10, -3)
        let expected = 7
        Assert.That(actual, Is.EqualTo(expected))
        
    [<Test>]
    let testMiddleOne () =
        let actual = middleOne (10, 42, -3)
        let expected = 42
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testSquareAndCubed () =
        let actual = squareAndCubed 5
        let expected = (25, 125)
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testMultArrays () =
        let actual = multArrays 5
        let expected = [5; 10; 15; 20]
        Assert.That(actual, Is.EqualTo(expected))

module TestGCD =
    [<Test>]
    let testGDC_9_15 () =
        let actual = euclids_gcd 9 15
        let expected = 3
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testGDC_6_8 () =
        let actual = euclids_gcd 6 8
        let expected = 2
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testGDC_42_49 () =
        let actual = euclids_gcd 42 49
        let expected = 7
        Assert.That(actual, Is.EqualTo(expected))

module TestPascalsTriangle =
    [<Test>]
    let testPascal0_0 () =
        let actual = pascalsTriangle 0 0
        let expected = 1
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testPascal1_0 () =
        let actual = pascalsTriangle 1 0
        let expected = 1
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testPascal1_1 () =
        let actual = pascalsTriangle 1 1
        let expected = 1
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testPascal2_1 () =
        let actual = pascalsTriangle 2 1
        let expected = 2
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testPascal3_1 () =
        let actual = pascalsTriangle 3 1
        let expected = 3
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testPascal3_2 () =
        let actual = pascalsTriangle 3 2
        let expected = 3
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testPascal7_3 () =
        let actual = pascalsTriangle 7 3
        let expected = 35
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testPascal7_6 () =
        let actual = pascalsTriangle 7 6
        let expected = 7
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testPascal7_7 () =
        let actual = pascalsTriangle 7 7
        let expected = 1
        Assert.That(actual, Is.EqualTo(expected))