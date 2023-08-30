namespace wit.comp3350

open NUnit.Framework
open wit.comp3350.la5

module TestHelper =
    let assertOptionIsNone (actual: option<'a>) =
        match actual with
        | None -> Assert.Pass()
        | _ -> Assert.Fail($"Expected: None\n     But was: {actual}")
        
    let assertOptionIsSome (actual: option<'a>) (expected: option<'a>) =
        match actual with
        | None -> Assert.Fail($"Expected: {expected}\n     But was: None")
        | _ -> Assert.That(actual, Is.EqualTo(expected))
        
    let assertListEquals (actual: 'a list) (expected: 'a list) =
        Assert.That(actual, Is.EqualTo(expected), $"Expected: {expected}\n     But was: {actual}")

    // A single-entry tree with just 3
    let tree3 = Node (Empty, 3, Empty)

    // A tree with 3 as root, and 1, 6 on either side
    // i.e.   3
    //       1 6
    let tree316 = 
        let lf = Node (Empty, 1, Empty)
        let rt = Node (Empty, 6, Empty)
        Node (lf, 3, rt)

    // A tree with 3 as root, 6 on right, and 5 and 9 under 6
    // i.e.  3
    //         6
    //        5 9
    let tree3659 = 
        let c9 = Node (Empty, 9, Empty)
        let c5 = Node (Empty, 5, Empty)
        let c6 = Node (c5, 6, c9)
        Node (Empty, 3, c6)

[<Timeout(400); OrderAttribute(1)>]
module TestTreeCount =
    open TestHelper

    [<Test>]
    let testCountE () =
        let actual = count Empty
        Assert.That(actual, Is.EqualTo(0))

    [<Test>]
    let testCount3 () =
        let actual = count tree3
        Assert.That(actual, Is.EqualTo(1))

    [<Test>]
    let testCount316 () =
        let actual = count tree316
        Assert.That(actual, Is.EqualTo(3))

    [<Test>]
    let testCount3659 () =
        let actual = count tree3659
        Assert.That(actual, Is.EqualTo(4))

[<Timeout(400); OrderAttribute(2)>]
module TestToListPreOrder =
    open TestHelper

    [<Test>]
    let testToList_E () =
        let actual = toListPreOrder Empty
        assertListEquals actual []

    [<Test>]
    let testToList_3 () =
        let actual = toListPreOrder tree3
        assertListEquals actual [3]

    [<Test>]
    let testToList_316 () =
        let actual = toListPreOrder tree316
        assertListEquals actual [3; 1; 6]

    [<Test>]
    let testToList_3659 () =
        let actual = toListPreOrder tree3659
        assertListEquals actual [3; 6; 5; 9]

[<Timeout(400); OrderAttribute(3)>]
module TestMinMax =
    open TestHelper

    [<Test>]
    let testMaxNone () =
        let actual = maxTree Empty
        assertOptionIsNone actual

    [<Test>]
    let testMax3 () =
        let actual = maxTree tree3
        assertOptionIsSome actual (Some 3)

    [<Test>]
    let testMax316 () =
        let actual = maxTree tree316
        assertOptionIsSome actual (Some 6)

    [<Test>]
    let testMax3659 () =
        let actual = maxTree tree3659
        assertOptionIsSome actual (Some 9)

[<Timeout(400); OrderAttribute(4)>]
module TestPathsum =
    open TestHelper

    [<Test>]
    let test_Pathsum_E_0 () =
        let actual = pathsum Empty 0
        Assert.That(actual, Is.True)

    [<Test>]
    let test_Pathsum_E_3 () =
        let actual = pathsum Empty 3
        Assert.That(actual, Is.False)

    [<Test>]
    let test_Pathsum_3_3 () =
        let actual = pathsum tree3 3
        Assert.That(actual, Is.True)

    [<Test>]
    let test_Pathsum_3_0 () =
        let actual = pathsum tree3 0
        Assert.That(actual, Is.False)

    [<Test>]
    let test_Pathsum_316_4 () =
        let actual = pathsum tree316 4
        Assert.That(actual, Is.True)

    [<Test>]
    let test_Pathsum_316_9 () =
        let actual = pathsum tree316 9
        Assert.That(actual, Is.True)

    [<Test>]
    let test_Pathsum_316_0 () =
        let actual = pathsum tree3 2
        Assert.That(actual, Is.False)

    [<Test>]
    let test_Pathsum_3659_14 () =
        let actual = pathsum tree3659 14
        Assert.That(actual, Is.True)

    [<Test>]
    let test_Pathsum_3659_18 () =
        let actual = pathsum tree3659 18
        Assert.That(actual, Is.True)

    [<Test>]
    let test_Pathsum_3659_10 () =
        let actual = pathsum tree3659 10
        Assert.That(actual, Is.False)

