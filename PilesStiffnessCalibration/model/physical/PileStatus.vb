''' <summary>
''' 
''' Enumeration made from different constants identifying the status of the pile: Loaded or Unloaded.
''' If the status is set to LOADED that means that the pile is currently subjected to a load greater than what it 
''' has been loaded with previously (UNLOADED viceversa).
''' This is particularly important when working with existing pile/soil springs which, if loaded with a load lower than what
''' they've ever been subjected to, they won't experience any settlement and their stiffness has to be considered 
''' essentially infinite (i.e. rigid).
''' 
''' </summary>

Public Enum PileStatus

    'ENUMERATION VALUES
    LOADED
    UNLOADED

End Enum
