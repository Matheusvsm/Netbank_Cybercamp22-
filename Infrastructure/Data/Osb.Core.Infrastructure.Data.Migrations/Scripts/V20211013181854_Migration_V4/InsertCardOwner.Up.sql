CREATE OR REPLACE FUNCTION public.insertcardowner(
	"paramOwnerTaxId" character varying,
	"paramFullName" character varying,
	"paramPhone" character varying,
	"paramMail" character varying,
	"paramBank" character varying,
	"paramBankBranch" character varying,
	"paramBankAccount" character varying,
	"paramBankAccountDigit" character varying,
	"paramCreationUserId" bigint,
	"paramUpdateUserId" bigint)
    RETURNS TABLE("CardOwnerId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."CardOwner"
	(
	"OwnerTaxId",
	"FullName",
	"Phone",
	"Mail",
	"Bank",
	"BankBranch",
	"BankAccount",
	"BankAccountDigit",
	"CreationDate",    
    "UpdateDate",
    "CreationUserId",
    "UpdateUserId"
	)
	VALUES
	(
	"paramOwnerTaxId",
	"paramFullName",
	"paramPhone",
	"paramMail",
	"paramBank",
	"paramBankBranch",
	"paramBankAccount",
	"paramBankAccountDigit",
	now(),    
    now(),
    "paramCreationUserId",
	"paramUpdateUserId"
	)
RETURNING "CardOwnerId";
$BODY$;

ALTER FUNCTION public.insertcardowner(character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, bigint, bigint)
    OWNER TO "OSB";