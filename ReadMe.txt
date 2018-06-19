	######################ATO C# Generate code for Validation. #################################
	############################################################################################
	This explains the steps require build the solution. 
	1. Download the zip file "ATO PAYEVNT 2018 Rule Implementation v1.0.Zip"
	2. Build the solution

	###################### Technical Implementation  #################################
	This solution is C#. 
	Solution uses the C# code for the Main forms and the Cross forms.
	This package contains files for both PAYEVNT and PAYEVNTEMP for Submit and Update actions.

	In the PAYEVNT2018RequestValidator.cs files under the Submit and Update folders, the 
	ValidateReport function has a parameter called "CreateAt". This parameter is used for 
	Rule VR.ATO.PAYEVNT.000194 as the Date and Time the message was received in the channel.  
	This will have to manually coded.

	Cross form rules in the code have always been implemented within the parent validator despite 
	where they are documented (i.e. parent/child validation rules). This implementation decision is
	based on efficiency and there will sometimes be deviations from the specifications.