namespace wit.comp3350

module la5 =

    /// <summary>This type represents a binary tree. A binary tree can either be
    ///  - An empty node
    ///  - An inner node that also contains data
    /// </summary>
    type BinaryTree<'a> =
        | Empty
        | Node of BinaryTree<'a> * 'a * BinaryTree<'a>

    /// TODO: Complete and document
    /// case 1: check empty return 0
    /// case 2: if 1 + recursive until it reach to all node
    let rec count tr =
        match tr with
        | Empty -> 0
        | Node(left, _, right) -> 1+ count left + count right

    /// TODO: Complete and document
    /// case 1; empty list
    /// case 2: value, then recursive and add anything on left tree/right tree
    let rec toListPreOrder tr =
        match tr with
        | Empty -> []
        | Node(left, value, right) -> [value] @ toListPreOrder left @ toListPreOrder right

    /// <summary>
    ///  Helper function that takes two options and one item, and returns the maximum of the three.
    /// </summary>
    /// case 1: check value options a and b, c, return max
    /// case 2: checl a, with b is none, so check a with c
    /// case 3: a is none, check b, so check b and c
    /// case 4: all options are none, so return c
    let threeMax (aop: 'a option) (bop: 'a option) (c: 'a) =
        match aop, bop with
        | Some aop, Some bop -> Some (max (max aop bop) c)
        | Some aop, None -> Some (max aop c)
        | None, Some bop -> Some (max bop c)
        | None, None -> Some c
        

    /// TODO: Complete and document
    /// case 1: return none
    /// case 2: recursive three max and inside maxtree to find maximum number 
    let rec maxTree t =
        match t with
        | Empty -> None
        | Node (lef, value, right) -> threeMax (maxTree lef) (maxTree right) (value)
         

    /// TODO: Complete and document
    /// case 1: empty node, but if s is 0 then true, else false
    /// case 2: if value equal to s , return true
    /// case 3: recursive pathsive left side, with s reduce by value, and same with 
    ///             right side, until it end 
    /// and return is both is true so true, but otherwise, false
    let rec pathsum tr s = 
        match tr with
        | Empty -> if (s = 0) then true else false 
        | Node (lef,value, righ) when (s = value) -> true
        | Node (lef,value, righ) -> 
            let lefttr = pathsum lef (s - value)
            let rightr = pathsum righ (s - value)
            lefttr || rightr

