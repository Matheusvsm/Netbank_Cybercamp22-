CREATE OR REPLACE FUNCTION public.insertcardholder(
	"paramHolderTaxId" character varying,
	"paramNationality" character varying,
	"paramMotherName" character varying,
	"paramGender" integer,
	"paramFullName" character varying,
	"paramBirthDate" character varying,
	"paramMaritalStatus" integer,
	"paramCreationUserId" bigint,
	"paramUpdateUserId" bigint)
    RETURNS TABLE("CardHolderId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."CardHolder"
	(
	"HolderTaxId",
	"Nationality",
	"MotherName",
	"Gender",
	"FullName",
	"BirthDate",
	"MaritalStatus",
	"CreationDate",    
    "UpdateDate",
    "CreationUserId",
    "UpdateUserId"
	)
	VALUES
	(
	"paramHolderTaxId",
	"paramNationality",
	"paramMotherName",
	"paramGender",
	"paramFullName",
	"paramBirthDate",
	"paramMaritalStatus",
	now(),    
    now(),
    "paramCreationUserId",
	"paramUpdateUserId"
	)
RETURNING "CardHolderId"
$BODY$;

ALTER FUNCTION public.insertcardholder(character varying, character varying, character varying, integer, character varying, character varying, integer, bigint, bigint)
    OWNER TO "OSB";
