
''' <summary>
''' 
''' Enumeration made from a number of identification constants for different types of Link properties.
''' Each Constant is associated to a specific Link property type. 
''' Whenever a Link property has to be identified as per one of the types represented by the 
''' constants of this Enum, it's sufficient to pass the enum constant as input and the proper
''' 
''' </summary>


Public Enum LinkPropertyType

    DAMPER
    DAMPERBILINEAR
    DAMPERFRICTIONSPRING
    FRICTIONISOLATOR
    GAP
    HOOK
    LINEAR
    MULTILINEARELASTIC
    MULTILINEARPLASTIC
    RUBBERISOLATOR

End Enum
