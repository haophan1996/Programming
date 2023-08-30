namespace wit.comp3350

module a3 =
    /// <summary>This type represents a linked list. Each node could either be:
    ///  - An empty node
    ///  - An node that also contains data
    /// </summary>
    type LinkedList<'a> =
        | EmptyList
        | LLNode of 'a * LinkedList<'a>

    /// <summary>This function adds a new item to the *end*.
    ///       It is already complete, and provided as reference.
    /// <param name="ls">A pointer to a linked list node</param>
    /// <param name="x">The item to add</param>
    /// </summary>
    let rec llAppend ls x =
        match ls with
        // If the node is empty, create a new node
        | EmptyList -> LLNode (x, EmptyList)
        // If the node is the last one, add a new node after this
        | LLNode (i, EmptyList) -> LLNode (i, LLNode (x, EmptyList))
        // If the node is *not* the last one, recursively call append
        // since we cannot add yet
        | LLNode (i, tls) -> LLNode (i, llAppend tls x)

    /// <summary>This function converts a list to a LinkedList.
    ///        It is already complete, and provided as reference.
    /// <param name="l">The list</param>
    /// </summary>
    let listToLL l =
        List.fold (fun a x -> llAppend a x) EmptyList l

    /// TODO: Complete and document
    let rec llToList ls =
        match ls with
        | EmptyList -> []
        | LLNode (i, EmptyList) -> [i]
        | LLNode (i, tls) -> [i] @ llToList tls

    /// TODO: Complete and document
    let rec llInsertSorted ls x =
        match ls with
        | EmptyList -> LLNode (x, EmptyList) 
        | LLNode (i, EmptyList) -> 
            if (i > x) then
                LLNode(x, LLNode(i, EmptyList))
            else LLNode(i, LLNode(x, EmptyList))
        | LLNode (i, tls) -> 
            if (x < i) then
                LLNode(x, LLNode(i, tls))
            else
                LLNode (i, llInsertSorted tls x) 
             
         

    /// <summary>This type represents a binary tree. A binary tree can either be
    ///  - An empty node
    ///  - An inner node that also contains data
    /// </summary>
    type BinaryTree<'a> =
        | Empty
        | Node of BinaryTree<'a> * 'a * BinaryTree<'a>

    /// TODO: Complete and document
    let rec insertBST tr x =
        match tr with
        | Empty -> Node (Empty,x,Empty)
        | Node (left,value,right) ->
            if (x < value) then
                Node (insertBST left x,value, right)
            else 
                Node (left,value, insertBST right x)

                 
            
    /// TODO: Complete and document (see listToLL for reference)
    let listToBST l =
        List.fold (fun a x -> insertBST a x) Empty l

    /// TODO: Complete and document
    let rec toList tr =
        match tr with
        | Empty -> []
        | Node (left,value,right)
            ->   toList left @ [value] @ toList right

    /// TODO: Complete and document
    let rec minBST t =
        match t with
        | Empty -> None
        | Node (left,value,_) -> 
            match left with
            |Empty -> Some value
            | _ -> minBST left

    /// TODO: Complete and document
    let rec maxBST t =
        match t with
        | Empty -> None
        | Node (_,value,right) -> 
            match right with
            |Empty -> Some value
            | _ -> maxBST right
