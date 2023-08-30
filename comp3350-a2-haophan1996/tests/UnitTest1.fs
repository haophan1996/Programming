namespace wit.comp3350

open NUnit.Framework
open wit.comp3350.a2

module TestHelper =
    let assertListEquals (actual: 'a list) (expected: 'a list) =
        Assert.That(actual, Is.EqualTo(expected), $"Expected: {expected}\n     But was: {actual}")

    let assertListEquivalent (actual: 'a list) (expected: 'a list) =
        let aSorted = List.sort actual
        let eSorted = List.sort expected
        Assert.That(aSorted, Is.EqualTo(eSorted), $"Expected: {eSorted}\n     But was: {aSorted}")

[<Timeout(400); OrderAttribute(1)>]
module TestCompress =

    [<Test>]
    let testCompress_AAA () =
        let actual = compress [ "A"; "A"; "A" ]
        TestHelper.assertListEquals actual [ "A" ]

    [<Test>]
    let testCompress_A () =
        let actual = compress [ "A" ]
        TestHelper.assertListEquals actual [ "A" ]

    [<Test>]
    let testCompress_AB () =
        let actual = compress [ "A"; "B" ]
        TestHelper.assertListEquals actual [ "A"; "B" ]

    [<Test>]
    let testCompress_ABB () =
        let actual = compress [ "A"; "B"; "B" ]
        TestHelper.assertListEquals actual [ "A"; "B" ]

    [<Test>]
    let testCompress_AABB () =
        let actual = compress [ "A"; "A"; "B"; "B" ]
        TestHelper.assertListEquals actual [ "A"; "B" ]

[<Timeout(400); OrderAttribute(2)>]
module TestSplit1 =

    [<Test>]
    let testSplit11 () =
        let actualFst, actualSnd = split1 [ 'a'; ','; 'b' ] ','
        TestHelper.assertListEquals actualFst [ 'a' ]
        TestHelper.assertListEquals actualSnd [ 'b' ]

    [<Test>]
    let testSplit20 () =
        let actualFst, actualSnd = split1 [ 'a'; 'b'; ',' ] ','
        TestHelper.assertListEquals actualFst [ 'a'; 'b' ]
        Assert.That(actualSnd, Is.Empty)

    [<Test>]
    let testSplit21 () =
        let actualFst, actualSnd = split1 [ 'a'; 'b'; ','; 'c' ] ','
        TestHelper.assertListEquals actualFst [ 'a'; 'b' ]
        TestHelper.assertListEquals actualSnd [ 'c' ]

    [<Test>]
    let testSplit03 () =
        let actualFst, actualSnd = split1 [ ','; 'a'; 'b'; 'c' ] ','
        Assert.That(actualFst, Is.Empty)
        TestHelper.assertListEquals actualSnd [ 'a'; 'b'; 'c' ]

    [<Test>]
    let testSplit04 () =
        let actualFst, actualSnd = split1 [ ','; 'a'; 'b'; ','; 'c' ] ','
        Assert.That(actualFst, Is.Empty)
        TestHelper.assertListEquals actualSnd [ 'a'; 'b'; ','; 'c' ]


[<Timeout(400); OrderAttribute(3)>]
module TestCount =

    [<Test>]
    let testCount_Pos () =
        let actual = count (fun x -> x > 0) [ 3; 1; -4; 0 ]
        Assert.That(actual, Is.EqualTo(2))

    [<Test>]
    let testCount_Neg () =
        let actual = count (fun x -> x < 0) [ 3; 1; -4; 0 ]
        Assert.That(actual, Is.EqualTo(1))

[<Timeout(400); OrderAttribute(4)>]
module TestJoin =

    [<Test>]
    let testJoin_wit_edu () =
        let actual = join [ "www"; "wit"; "edu" ] "."
        Assert.That(actual, Is.EqualTo("www.wit.edu"))

    [<Test>]
    let testJoin_dobbs () =
        let actual = join [ "dobbs" ] "."
        Assert.That(actual, Is.EqualTo("dobbs"))

[<Timeout(400); OrderAttribute(5)>]
module TestSortPairs =

    [<Test>]
    let testSortAB () =
        let actual = sortPairs [ ("Alice", "Bob") ]
        TestHelper.assertListEquals actual [ ("Alice", "Bob") ]

    [<Test>]
    let testSortBA () =
        let actual = sortPairs [ ("Bob", "Alice") ]
        TestHelper.assertListEquals actual [ ("Alice", "Bob") ]

    [<Test>]
    let testSortAA () =
        let actual =
            sortPairs [ ("Bob", "Alice")
                        ("andrew", "alice") ]

        TestHelper.assertListEquals
            actual
            [ ("alice", "andrew")
              ("Alice", "Bob") ]

    [<Test>]
    let testSortBACD () =
        let actual =
            sortPairs [ ("Bob", "Alice")
                        ("Charles", "Dennis") ]

        TestHelper.assertListEquals
            actual
            [ ("Alice", "Bob")
              ("Charles", "Dennis") ]


    [<Test>]
    let testSortBACDCE () =
        let actual =
            sortPairs [ ("Bob", "Alice")
                        ("Charles", "Dennis")
                        ("Emma", "Charles") ]

        TestHelper.assertListEquals
            actual
            [ ("Alice", "Bob")
              ("Charles", "Dennis")
              ("Charles", "Emma") ]

[<Timeout(400); OrderAttribute(6)>]
module TestFlipper =

    [<Test>]
    let testFlipH () =
        let actual = flip [ 'h' ]
        Assert.That(actual, Is.EqualTo((3, 4, 1, 2)))

    [<Test>]
    let testFlipV () =
        let actual = flip [ 'v' ]
        Assert.That(actual, Is.EqualTo((2, 1, 4, 3)))

    [<Test>]
    let testFlipHV () =
        let actual = flip [ 'h'; 'v' ]
        Assert.That(actual, Is.EqualTo((4, 3, 2, 1)))

    [<Test>]
    let testFlipHVH () =
        let actual = flip [ 'h'; 'v'; 'h' ]
        Assert.That(actual, Is.EqualTo((2, 1, 4, 3)))

    [<Test>]
    let testFlipHVVH () =
        let actual = flip [ 'h'; 'v'; 'v'; 'h' ]
        Assert.That(actual, Is.EqualTo((1, 2, 3, 4)))

[<Timeout(400); OrderAttribute(7)>]
module TestRotatingLetters =

    [<Test>]
    let testValidX () =
        let actual = either 'X' validChars
        Assert.That(actual, Is.True)

    [<Test>]
    let testInvalidT () =
        let actual = either 'T' validChars
        Assert.That(actual, Is.False)

    [<Test>]
    let testRotatingX () =
        let actual = rotatingLetters [ 'X' ]
        Assert.That(actual, Is.True)

    [<Test>]
    let testRotatingNOSHO () =
        let input = "NOSHO".ToCharArray() |> Array.toList
        let actual =
            rotatingLetters input

        Assert.That(actual, Is.True)

    [<Test>]
    let testRotatingISHOT () =
        let input = "ISHOT".ToCharArray() |> Array.toList
        let actual =
            rotatingLetters input

        Assert.That(actual, Is.False)
