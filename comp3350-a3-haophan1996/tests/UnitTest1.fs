namespace wit.comp3350

open NUnit.Framework
open wit.comp3350.a3

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
        let fmt = sprintf "Expected: %A\n     But was: %A"
        Assert.That(actual, Is.EqualTo(expected), (fmt expected actual))

[<Timeout(400); OrderAttribute(1)>]
module TestLLAppend =
    [<Test>]
    let testLLAppend_1 () =
        let actual = llAppend EmptyList 11
        Assert.That(actual, Is.EqualTo(LLNode(11, EmptyList)))

    [<Test>]
    let testLLAppend_12 () =
        let actual = listToLL [ 11; 12 ]
        let expected = LLNode(11, LLNode(12, EmptyList))
        Assert.That(actual, Is.EqualTo(LLNode(11, LLNode(12, EmptyList))))

    [<Test>]
    let testLLAppend_1234 () =
        let actual = listToLL [ 11; 12; 13; 14 ]
        let expected = LLNode(11, LLNode(12, LLNode(13, LLNode(14, EmptyList))))
        Assert.That(actual, Is.EqualTo(expected))

[<Timeout(400); OrderAttribute(2)>]
module TestListToList =
    open TestHelper

    [<Test>]
    let testLLToList_E () =
        let actual = llToList EmptyList
        Assert.That(actual, Is.Empty)

    [<Test>]
    let testLLToList_1 () =
        let actual = [ 11 ] |> listToLL |> llToList
        assertListEquals actual [ 11 ]

    [<Test>]
    let testLLToList_123 () =
        let actual = [ 11; 12; 13 ] |> listToLL |> llToList
        assertListEquals actual [ 11; 12; 13 ]

    [<Test>]
    let testLLToList_1234555 () =
        let actual =
            [ 11; 12; 13; 14; 15; 15; 15 ]
            |> listToLL
            |> llToList

        assertListEquals actual [ 11; 12; 13; 14; 15; 15; 15 ]

[<Timeout(400); OrderAttribute(3)>]
module TestListSorted =
    open TestHelper

    let listToSortedLL l =
        List.fold (fun a x -> llInsertSorted a x) EmptyList l

    [<Test>]
    let testLLToList_E () =
        let actual = listToSortedLL [ 11 ] |> llToList
        assertListEquals actual [ 11 ]

    [<Test>]
    let testLLToList_31 () =
        let actual = listToSortedLL [ 13; 11 ] |> llToList
        assertListEquals actual [ 11; 13 ]

    [<Test>]
    let testLLToList_134 () =
        let actual = listToSortedLL [ 13; 11; 14 ] |> llToList
        assertListEquals actual [ 11; 13; 14 ]

    [<Test>]
    let testLLToList_1340 () =
        let actual = listToSortedLL [ 13; 11; 14; 10 ] |> llToList
        assertListEquals actual [ 10; 11; 13; 14 ]

[<Timeout(400); OrderAttribute(3)>]
module TestInsertBST =
    [<Test>]
    let testInsertBST_1 () =
        let actual = insertBST Empty 1
        Assert.That(actual, Is.EqualTo(Node(Empty, 1, Empty)))

    [<Test>]
    let testInsertBST_12 () =
        let actual = listToBST [ 11; 12 ]
        Assert.That(actual, Is.EqualTo(Node(Empty, 11, Node(Empty, 12, Empty))))

    [<Test>]
    let testInsertBST_1234 () =
        // Should return a tree
        //      11
        //        12
        //         13
        //           14
        let actual = listToBST [ 11; 12; 13; 14 ]
        Assert.That(actual, Is.EqualTo(Node(Empty, 11, Node(Empty, 12, Node(Empty, 13, Node(Empty, 14, Empty))))))

    [<Test>]
    let testInsertBST_1342 () =
        // Should return a tree
        //      11
        //         13
        //       12  14
        let actual = listToBST [ 11; 13; 14; 12 ]
        Assert.That(actual, Is.EqualTo(Node(Empty, 11, Node(Node(Empty, 12, Empty), 13, Node(Empty, 14, Empty)))))

    [<Test>]
    let testInsertBST_4321 () =
        // Should return a tree
        //           14
        //         13
        //       12
        //     11
        let actual = listToBST [ 14; 13; 12; 11 ]
        Assert.That(actual, Is.EqualTo(Node(Node(Node(Node(Empty, 11, Empty), 12, Empty), 13, Empty), 14, Empty)))

[<Timeout(400); OrderAttribute(4)>]
module TestBStToList =
    open TestHelper

    [<Test>]
    let testBSTToList_1 () =
        let actual = insertBST Empty 1 |> toList
        assertListEquals actual [ 1 ]

    [<Test>]
    let testBSTToList_E () =
        let actual = Empty |> toList
        assertListEquals actual []

    [<Test>]
    let testBSTToList_1234 () =
        let actual = [ 11; 12; 13; 14 ] |> listToBST |> toList
        assertListEquals actual [ 11; 12; 13; 14 ]

    [<Test>]
    let testBSTToList_1342 () =
        let actual = [ 11; 13; 14; 12 ] |> listToBST |> toList
        assertListEquals actual [ 11; 12; 13; 14 ]

[<Timeout(400); OrderAttribute(1)>]
module TestMinMax =
    open TestHelper

    [<Test>]
    let testMinNone () =
        let actual = Empty |> minBST
        assertOptionIsNone actual

    [<Test>]
    let testMaxNone () =
        let actual = Empty |> maxBST
        assertOptionIsNone actual

    [<Test>]
    let testMin7 () =
        let actual = insertBST Empty 7 |> minBST
        assertOptionIsSome actual (Some 7)

    [<Test>]
    let testMax7 () =
        let actual = insertBST Empty 7 |> maxBST
        assertOptionIsSome actual (Some 7)

    [<Test>]
    let testMin78 () =
        let actual = [ 7; 8 ] |> listToBST |> minBST
        assertOptionIsSome actual (Some 7)

    [<Test>]
    let testMax78 () =
        let actual = [ 7; 8 ] |> listToBST |> maxBST
        assertOptionIsSome actual (Some 8)

    [<Test>]
    let testMin6859 () =
        let actual = [ 6; 8; 5; 9 ] |> listToBST |> minBST
        assertOptionIsSome actual (Some 5)

    [<Test>]
    let testMax6859 () =
        let actual = [ 6; 8; 5; 9 ] |> listToBST |> maxBST
        assertOptionIsSome actual (Some 9)
