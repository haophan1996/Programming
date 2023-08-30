namespace WIT.COMP3350

open NUnit.Framework
open WIT.COMP3350.LA4

module TestHelper =
    let assertIsNone (actual: option<'a>) =
        match actual with
        | None -> Assert.Pass()
        | _ -> Assert.Fail($"Expected: None\n     But was: {actual}")
        
    let assertIsSome (actual: option<'a>) (expected: option<'a>) =
        match actual with
        | None -> Assert.Fail($"Expected: {expected}\n     But was: None")
        | _ -> Assert.That(actual, Is.EqualTo(expected))
        
    let assertListEquals (actual: 'a list) (expected: 'a list) =
        Assert.That(actual, Is.EqualTo(expected), $"Expected: {expected}\n     But was: {actual}")

module TestShapes =

    [<Test>]
    let testIsCircleYes () =
        let a = Circle 3
        let actual = isCircle a
        Assert.That(actual, Is.True)

    [<Test>]
    let testIsCircleNo () =
        let a = Rectangle (5, 9)
        let actual = isCircle a
        Assert.That(actual, Is.False)

    [<Test>]
    let testIsRectangleYes () =
        let a = Rectangle (5, 9)
        let actual = isRectangle a
        Assert.That(actual, Is.True)

    [<Test>]
    let testIsRectangleNo () =
        let a = Circle 3
        let actual = isRectangle a
        Assert.That(actual, Is.False)

    [<Test>]
    let testIsCircleSquare () =
        let a = Circle 3
        let actual = isSquare a
        Assert.That(actual, Is.False)

    [<Test>]
    let testIsRectangleSquare () =
        let a = Rectangle (5, 9)
        let actual = isSquare a
        Assert.That(actual, Is.False)

    [<Test>]
    let testIsSquare () =
        let a = Rectangle (5, 5)
        let actual = isSquare a
        Assert.That(actual, Is.True)

    [<Test>]
    let testCount3 () =
        let l = [Circle 3; Circle 5; Circle 9]
        let actual = countCircles l
        Assert.That(actual, Is.EqualTo(3))

    [<Test>]
    let testCount2 () =
        let l = [Circle 3; Rectangle (3, 5); Circle 9]
        let actual = countCircles l
        Assert.That(actual, Is.EqualTo(2))

    [<Test>]
    let testCount0 () =
        let l = [Rectangle (1, 1); Rectangle (3, 5); Rectangle (1, 2)]
        let actual = countCircles l
        Assert.That(actual, Is.EqualTo(0))

module TestTryMin =

    [<Test>]
    let testTryMinEmpty () =
        let actual = tryMin []
        TestHelper.assertIsNone actual
        
    [<Test>]
    let testTryMin11 () =
        let actual = tryMin [11]
        TestHelper.assertIsSome actual (Some 11)
        
    [<Test>]
    let testTryMin1230 () =
        let actual = tryMin [11; 13; 12; 10]
        TestHelper.assertIsSome actual (Some 10)

module TestTryNth =

    [<Test>]
    let testTryNthEmpty () =
        let actual = tryNth 0 []
        TestHelper.assertIsNone actual
        
    [<Test>]
    let testTry0th () =
        let actual = tryNth 0 [11]
        TestHelper.assertIsSome actual (Some 11)
        
    [<Test>]
    let testTry0th12 () =
        let actual = tryNth 0 [11; 12]
        TestHelper.assertIsSome actual (Some 11)
        
    [<Test>]
    let testTry1th12 () =
        let actual = tryNth 1 [11; 12]
        TestHelper.assertIsSome actual (Some 12)
        
    [<Test>]
    let testTry2th12 () =
        let actual = tryNth 2 [11; 12]
        TestHelper.assertIsNone actual

module TestTryFindIdx =
    let isPos x = x > 0

    [<Test>]
    let testTryFindIdxEmpty () =
        let actual = tryFindIdx isPos []
        TestHelper.assertIsNone actual

    [<Test>]
    let testTryFindIdx1 () =
        let actual = tryFindIdx isPos [1]
        TestHelper.assertIsSome actual (Some 0)

    [<Test>]
    let testTryFindIdxn1 () =
        let actual = tryFindIdx isPos [-1; 1]
        TestHelper.assertIsSome actual (Some 1)

    [<Test>]
    let testTryFindIdxnn1 () =
        let actual = tryFindIdx isPos [-1; -2; 1]
        TestHelper.assertIsSome actual (Some 2)

    [<Test>]
    let testTryFindIdxn12 () =
        let actual = tryFindIdx isPos [-1; 1; 2]
        TestHelper.assertIsSome actual (Some 1)

