namespace wit.comp3350

module la2 =
    /// TODO
    let addPair p =
        let n1, n2 = p
        n1 + n2

    /// TODO
    let middleOne triplet =
        let _, b, c = triplet
        b

    /// TODO
    let squareAndCubed x =
        (x*x, x*x*x)

    /// TODO
    let multArrays x =
        [x; 2*x; 3*x; 4*x]

    /// TODO
    let rec euclids_gcd x y =
        if x = 0 then y
        else if y  = 0 then x
        else if x > y then euclids_gcd y (x%y)
        else euclids_gcd x (y%x)

    /// TODO
    let rec pascalsTriangle row idx =
        if row = 0 then 1
        else if idx = 0 then 1
        else if idx = row then 1
        else (pascalsTriangle (row-1) idx) + (pascalsTriangle (row-1) (idx-1))
