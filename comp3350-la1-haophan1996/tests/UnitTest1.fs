namespace wit.comp3350

open NUnit.Framework
open wit.comp3350.la1

[<TestFixture>]
module tests =

    [<Test>]
    let testXY2p_00 () =
        let x, y, expected = 0, 0, 0
        let actual = xy_sqpl x y
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testXY2p_74 () =
        let x, y, expected = 7, 4, 11
        let actual = xy_sqpl x y
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testXY2p_7n4 () =
        let x, y, expected = 7, -4, 11
        let actual = xy_sqpl x y
        Assert.That(actual, Is.EqualTo(expected))

module testIsPositive =

    [<Test>]
    let testIsPositive_0 () =
        let x, expected = 0, false
        let actual = isPositive x
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testIsPositive_3 () =
        let x, expected = 3, true
        let actual = isPositive x
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testIsPositive_n7 () =
        let x, expected = -7, false
        let actual = isPositive x
        Assert.That(actual, Is.EqualTo(expected))

module testIsNonzero =

    [<Test>]
    let testIsNonzero_0 () =
        let x, expected = 0, false
        let actual = isNonZero x
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testIsNonzero_3 () =
        let x, expected = 3, true
        let actual = isNonZero x
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testIsNonzero_n7 () =
        let x, expected = -7, true
        let actual = isNonZero x
        Assert.That(actual, Is.EqualTo(expected))

module testBothNonzero =

    [<Test>]
    let testBothNonzero_0_0 () =
        let x, y, expected = 0, 0, false
        let actual = bothNonZero x y
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testBothNonzero_3_n7 () =
        let x, y, expected = 3, -7, true
        let actual = bothNonZero x y
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testBothNonzero_0_n7 () =
        let x, y, expected = 0, -7, false
        let actual = bothNonZero x y
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testBothNonzero_3_0 () =
        let x, y, expected = 3, 0, false
        let actual = bothNonZero x y
        Assert.That(actual, Is.EqualTo(expected))

module testNumTotal =

    [<Test>]
    let testNumTotal_1_1 () =
        let x, y, expected = 1, 1, 11
        let actual = numTotal x y
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testNumTotal_3_0 () =
        let x, y, expected = 3, 0, 24
        let actual = numTotal x y
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testNumTotal_0_7 () =
        let x, y, expected = 0, 7, 21
        let actual = numTotal x y
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testNumTotal_0_0 () =
        let x, y, expected = 0, 0, 0
        let actual = numTotal x y
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testNumTotal_n3_1 () =
        let x, y, expected = -3, 7, 0
        let actual = numTotal x y
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testNumTotal_3_n7 () =
        let x, y, expected = 3, -7, 0
        let actual = numTotal x y
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testNumTotal_n3_n7 () =
        let x, y, expected = -3, -7, 0
        let actual = numTotal x y
        Assert.That(actual, Is.EqualTo(expected))
