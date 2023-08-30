namespace wit.comp3350

module la1 =
    //// TODO: Document this
    let xy_sqpl x y = abs x + abs y

    /// TODO: Document this
    let isPositive x = if (x > 0) then true else false

    /// TODO: Document this
    let isNonZero x = if (x <> 0) then true else false

    /// TODO: Document this
    let bothNonZero x y =  if ( (x = 0) || (y =0)) then false else true

    /// TODO: Document this
    let r_is_Pos r = if (r >= 0) then true else false
    let s_is_Pos s = if (s >= 0) then true else false

    let calculate_r_s r s= if ((r_is_Pos r) && (r_is_Pos s) = true) then xy_sqpl (r*8) (s*3) else 0
    let numTotal r s = calculate_r_s r s
