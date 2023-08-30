namespace WIT.COMP3350

open NUnit.Framework
open WIT.COMP3350.IC1

[<TestFixture>]
module testAdd2 =

    [<Test>]
    let testIsAdd2_0_0 () =
        let x, y, expected = 0, 0, 0
        let actual = add2 x y
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testIsAdd2_7_4 () =
        let x, y, expected = 7, 4, 11
        let actual = add2 x y
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    let testIsAdd2_n13_29 () =
        let x, y, expected = -13, 29, 16
        let actual = add2 x y
        Assert.That(actual, Is.EqualTo(expected))

