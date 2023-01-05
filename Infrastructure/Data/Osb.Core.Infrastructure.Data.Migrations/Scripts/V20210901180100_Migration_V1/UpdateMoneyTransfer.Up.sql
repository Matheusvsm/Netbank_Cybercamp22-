CREATE OR REPLACE FUNCTION public.updatemoneytransfer(
	"paramId" bigint,
	"paramExternalIdentifier" bigint,
    "paramAttempts" integer,
	"paramStatus" integer,
	"paramUpdateUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."MoneyTransfer"
	SET                
		"Status" = "paramStatus",
		"ExternalIdentifier" = "paramExternalIdentifier",
        "Attempts" = "paramAttempts",
		"UpdateDate" = Now(),
		"UpdateUserId" = "paramUpdateUserId"
	WHERE 
		"DeletionDate" IS NULL AND
		"MoneyTransferId" = "paramId"
$BODY$;

ALTER FUNCTION public.updatemoneytransfer(bigint, bigint, integer, integer, bigint)
    OWNER TO "OSB";