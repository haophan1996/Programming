namespace wit.comp3350

module a1 =
    /// TODO: Complete and document 
    /// case 1: if empty, so return empty
    /// case 2: if head not equal x, so head element, and call another functinon tail and x
    /// case 3: so since we only remove first match, then we return rest element
    let rec removeFirstX l x =
        match l with
        | [] -> []  
        | h :: t when (h <> x) -> h :: (removeFirstX t x)
        | h :: t ->  t

    /// TODO: Complete and document
    /// case 1: if empty, so return empty
    /// case 2: if head not equal x, so head element, and call another functinon tail and x
    /// case 3: so since we need to remove all match, then we will another func tail and x
    let rec removeAllX l x =
        match l with
        | [] -> []
        | h :: t when (h <> x) -> h :: (removeAllX t x)
        | h :: t -> (removeAllX t x)
        
         
    
    /// TODO: Complete and document
    /// case 1: if both list is empty, return empty
    /// case 2: get both head add together then recursive with function tail from v1 and v2
    /// case 3: check if v1 and v2 are not equal, invalid
    let rec vecAdd v1 v2 =
        match v1, v2 with
        | [],[] -> []
        | v1h :: v1t, v2h :: v2t -> (v1h+v2h) :: (vecAdd v1t v2t)
        | _,_ -> [] 

    /// TODO: Complete and document
    /// case 1, 2 ,3 check if empty, or l1 empty and l2 is not empty
    /// case 4: only check if both head are not epqual, so return false
    /// case 5: recursive function with both tails
    let rec equivalent l1 l2 =
        match l1, l2 with
        | [], [] -> true
        | [], _ -> false
        | _, [] -> false
        | l1h :: l1t, l2h :: l2t when (l1h <> l2h) -> false
        | l1h :: l1t, l2h :: l2t -> (equivalent l1t l2t)
        


    /// TODO: Complete and document
    /// case 1: if 0, return empty list
    /// case 2: we take anynumber, and call
    ///     recussive number except last digit, 
    ///     @ (add) x % 10 that save this last digit to list
    let rec intToList x =
        match x with
        | 0 -> []
        | _ ->  intToList (x / 10) @ [x % 10]
         

    /// This function to support triangleTimes
    /// case 1: empty list, or list with 1 element return false
    /// case 2: check if head equal to first element in tail, return true
    /// case 3: recusive function with head and tail except first element in tail
    let rec isosceles l = 
        match l with
        | [] | [_] -> false
        | h :: t when (h = t.Head) -> true
        | h :: t -> isosceles (h::t.Tail)


    /// TODO: Complete and document
    /// first if: check if all angle is equal 180, if not return 'error
    /// second if: use equivalent to check if all angle are equal to each other
    /// third if: call this isosceles
    /// last if: return Scalene
    let triangleTimes triangle =
        let a,b,c = triangle
        if (a + b + c <> 180 ) then
            "Error"
        elif (equivalent [a;b] [b;c] = true) then
            "Equilateral"
        elif (isosceles [a;b;c] = true) then
            "Isosceles"
        else 
            "Scalene"

    /// TODO: Complete and document
    /// CCC'22 J2
    /// case 1: return 0 if list empty
    /// case 2: check if goal * 5 - fouls * 3 is greater than 40, if so, we add 1 + recusive tail
    /// case 3: recusive function with tail 
    let rec fergusonBall l =
        match l with
        | [] -> 0
        | (g, f) :: t when ( g * 5 - f * 3 > 40 ) -> 1 + fergusonBall t
        | (g, f) :: t -> fergusonBall t
        
