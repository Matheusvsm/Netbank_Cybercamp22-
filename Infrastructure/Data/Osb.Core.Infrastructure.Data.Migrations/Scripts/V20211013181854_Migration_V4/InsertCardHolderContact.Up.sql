CREATE OR REPLACE FUNCTION public.insertcardholdercontact(
	"paramPhone" character varying,
	"paramMail" character varying,
	"paramCreationUserId" bigint,
	"paramUpdateUserId" bigint)
    RETURNS TABLE("CardHolderContactId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."CardHolderContact"
	(
	"Phone",
	"Mail",
	"CreationDate",    
    "UpdateDate",
    "CreationUserId",
    "UpdateUserId"
	)
	VALUES
	(
	"paramPhone",
	"paramMail",
	now(),    
    now(),
    "paramCreationUserId",
	"paramUpdateUserId"
	)
RETURNING "CardHolderContactId";
$BODY$;

ALTER FUNCTION public.insertcardholdercontact(character varying, character varying, bigint, bigint)
    OWNER TO "OSB";