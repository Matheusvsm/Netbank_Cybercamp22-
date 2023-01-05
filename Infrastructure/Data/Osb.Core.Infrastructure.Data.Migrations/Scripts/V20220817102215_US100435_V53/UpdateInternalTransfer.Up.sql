DROP FUNCTION public.updateinternaltransfer(bigint, bigint, integer, integer, bigint);

CREATE OR REPLACE FUNCTION public.updateinternaltransfer(
	"paramId" bigint,
	"paramExternalIdentifier" bigint,
	"paramStatus" integer,
	"paramAttempts" integer,
	"paramUpdateUserId" bigint,
    "paramResponseMessage" character varying
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."InternalTransfer"
	SET
		"ExternalIdentifier" = "paramExternalIdentifier",
		"Status" = "paramStatus",
		"Attempts" = "paramAttempts",
		"UpdateUserId" = "paramUpdateUserId",
        "ResponseMessage" = "paramResponseMessage",
		"UpdateDate" = now()
	WHERE 
		"InternalTransferId" = "paramId"
$BODY$;

ALTER FUNCTION public.updateinternaltransfer(bigint, bigint, integer, integer, bigint, character varying)
    OWNER TO "OSB";