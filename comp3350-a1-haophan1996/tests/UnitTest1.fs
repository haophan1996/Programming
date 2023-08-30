namespace wit.comp3350

open NUnit.Framework
open wit.comp3350.a1

[<Timeout(400); OrderAttribute(1)>]
module TestRemoveFirstX =
    [<Test>]
    let testRemoveFirstXEmpty () =
        let actual = removeFirstX [] 4
        Assert.That(actual, Is.Empty)

    [<Test>]
    let testRemoveFirstXOne4 () =
        let actual = removeFirstX [4; 4] 4
        Assert.That(actual, Is.EqualTo([4]))

    [<Test>]
    let testRemoveFirstXTwo4 () =
        let actual = removeFirstX [4; 4] 4
        Assert.That(actual, Is.EqualTo([4]))

    [<Test>]
    let testRemoveFirstX454 () =
        let actual = removeFirstX [4; 5; 4] 4
        Assert.That(actual, Is.EqualTo([5; 4]))

    [<Test>]
    let testRemoveFirstX547 () =
        let actual = removeFirstX [5; 4; 7] 4
        Assert.That(actual, Is.EqualTo([5; 7]))

    [<Test>]
    let testRemoveFirstX544 () =
        let actual = removeFirstX [5; 4; 4] 4
        Assert.That(actual, Is.EqualTo([5; 4]))

[<Timeout(400); OrderAttribute(2)>]
module TestRemoveAllX =
    [<Test>]
    let testRemoveAllXEmpty () =
        let actual = removeAllX [] 4
        Assert.That(actual, Is.Empty)

    [<Test>]
    let testRemoveAllXOne4 () =
        let actual = removeAllX [4] 4
        Assert.That(actual, Is.Empty)

    [<Test>]
    let testRemoveAllXTwo4 () =
        let actual = removeAllX [4; 4] 4
        Assert.That(actual, Is.Empty)

    [<Test>]
    let testRemoveAllX454 () =
        let actual = removeAllX [4; 5; 4] 4
        Assert.That(actual, Is.EqualTo([5]))

    [<Test>]
    let testRemoveAllX547 () =
        let actual = removeAllX [5; 4; 7] 4
        Assert.That(actual, Is.EqualTo([5; 7]).AsCollection)

    [<Test>]
    let testRemoveAllX544 () =
        let actual = removeAllX [5; 4; 4] 4
        Assert.That(actual, Is.EqualTo([5]))

[<Timeout(400);  OrderAttribute(3)>]
module TestIntToLst =
    [<Test>]
    let testIntToListSeven () =
        let actual = intToList 7
        Assert.That(actual, Is.EqualTo([7]))

    [<Test>]
    let testIntToListFifteen () =
        let actual = intToList 15
        Assert.That(actual, Is.EqualTo([1; 5]))

    [<Test>]
    let testIntToListFourTwoThree () =
        let actual = intToList 423
        Assert.That(actual, Is.EqualTo([4; 2; 3]))

    [<Test>]
    let testIntToListNineSevenSixEightZero () =
        let actual = intToList 97680
        Assert.That(actual, Is.EqualTo([9; 7; 6; 8; 0]))

[<Timeout(400);  OrderAttribute(4)>]
module TestVecAdd =
    [<Test>]
    let testVecAdd1 () =
        let actual = vecAdd [10; 20] [11; 21]
        Assert.That(actual, Is.EqualTo([21; 41]))

    [<Test>]
    let testVecAdd2 () =
        let actual = vecAdd [10; 20; 30; 40] [11; 12; 13; 14]
        Assert.That(actual, Is.EqualTo([21; 32; 43; 54]))

    [<Test>]
    let testVecAdd0 () =
        let actual = vecAdd [] []
        Assert.That(actual, Is.Empty)

[<Timeout(400);  OrderAttribute(5)>]
module TestEquivalent =
    [<Test>]
    let testEquivalentEmptyEmpty () =
        let actual = equivalent [] []
        Assert.That(actual, Is.True)

    [<Test>]
    let testEquivalentOneOne () =
        let actual = equivalent [11] [11]
        Assert.That(actual, Is.True)

    [<Test>]
    let testEquivalentThreeThree () =
        let actual = equivalent [11; 12; 13] [11; 12; 13]
        Assert.That(actual, Is.True)

    [<Test>]
    let testEquivalentThreeOne () =
        let actual = equivalent [11; 12] [11; 12; 13]
        Assert.That(actual, Is.False)

    [<Test>]
    let testEquivalentNoneTwo () =
        let actual = equivalent [] [11; 12]
        Assert.That(actual, Is.False)

    [<Test>]
    let testEquivalentTwoNone () =
        let actual = equivalent [11; 12] []
        Assert.That(actual, Is.False)

[<Timeout(400);  OrderAttribute(7)>]
module TestTriangle =
    [<Test>]
    let testTriangleEquilateral () =
        let actual = triangleTimes (60, 60, 60)
        Assert.That(actual, Is.EqualTo("Equilateral"))

    [<Test>]
    let testTriangleError1 () =
        let actual = triangleTimes (40, 50, 40)
        Assert.That(actual, Is.EqualTo("Error"))
        
    [<Test>]
    let testTriangleError2 () =
        let actual = triangleTimes (70, 60, 65)
        Assert.That(actual, Is.EqualTo("Error"))
        
    [<Test>] 
    let testTriangleIso () =
        let actual = triangleTimes (50, 80, 50)
        Assert.That(actual, Is.EqualTo("Isosceles"))
        
    [<Test>]
    let testTriangleScalene () =
        let actual = triangleTimes (50, 60, 70)
        Assert.That(actual, Is.EqualTo("Scalene"))

[<Timeout(400);  OrderAttribute(8)>]
module TestFergusonBall =
    [<Test>]
    let testFergusonBallEmpty () =
        let actual = fergusonBall []
        Assert.That(actual, Is.EqualTo(0))

    [<Test>]
    let testFergusonBallOneStar () =
        let actual = fergusonBall [(12, 4)]
        Assert.That(actual, Is.EqualTo(1))

    [<Test>]
    let testFergusonBallOneNo () =
        let actual = fergusonBall [(8, 0)]
        Assert.That(actual, Is.EqualTo(0))

    [<Test>]
    let testFergusonBallTwoStar () =
        let actual = fergusonBall [(12, 4); (13, 1)]
        Assert.That(actual, Is.EqualTo(2))

    [<Test>]
    let testFergusonBallOneStarNo () =
        let actual = fergusonBall [(8, 0); (13, 1)]
        Assert.That(actual, Is.EqualTo(1))


