CREATE OR REPLACE FUNCTION public.updatependinginternaltransfer(
	"paramPendingInternalTransferId" bigint,
	"paramStatus" integer,
	"paramAttempts" integer,
	"paramUpdateUserId" bigint,
	"paramExternalIdentifier" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."PendingInternalTransfer"
			  SET
                "Status" = "paramStatus",
				"Attempts" = "paramAttempts",
				"ExternalIdentifier" = "paramExternalIdentifier",
				"UpdateUserId" = "paramUpdateUserId",
                "UpdateDate" = now()
		 	  WHERE 
	            "PendingInternalTransferId" = "paramPendingInternalTransferId"
$BODY$;

ALTER FUNCTION public.updatependinginternaltransfer(bigint, integer, integer, bigint, bigint)
    OWNER TO "OSB";