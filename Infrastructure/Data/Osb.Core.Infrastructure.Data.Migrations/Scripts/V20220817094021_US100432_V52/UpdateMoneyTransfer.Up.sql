DROP FUNCTION IF EXISTS public.updatemoneytransfer(bigint, bigint, integer, integer, bigint);

CREATE FUNCTION public.updatemoneytransfer(
	"paramId" bigint,
	"paramExternalIdentifier" bigint,
	"paramAttempts" integer,
	"paramStatus" integer,
	"paramUpdateUserId" bigint,
	"paramResponseMessage" character varying)
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
		"UpdateUserId" = "paramUpdateUserId",
		"ResponseMessage" = "paramResponseMessage"
	WHERE 
		"DeletionDate" IS NULL AND
		"MoneyTransferId" = "paramId"
$BODY$;

ALTER FUNCTION public.updatemoneytransfer(bigint, bigint, integer, integer, bigint, character varying)
    OWNER TO "OSB";