DROP FUNCTION public.updatetopup(bigint, bigint, character varying, character varying, character varying, character varying, integer, integer, bigint);

CREATE OR REPLACE FUNCTION public.updatetopup(
	"paramTopUpId" bigint,
	"paramExternalIdentifier" bigint,
	"paramUrlReceipt" character varying,
	"paramOriginNSU" character varying,
	"paramStatus" integer,
	"paramAttempts" integer,
	"paramUpdateUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."TopUp"
			  SET
                "ExternalIdentifier" = "paramExternalIdentifier",
                "UrlReceipt" = "paramUrlReceipt",
				"OriginNSU" = "paramOriginNSU",
                "Status" = "paramStatus",
                "Attempts" = "paramAttempts",
                "UpdateUserId" = "paramUpdateUserId",
                "UpdateDate" = now()
		 	  WHERE 
	            "TopUpId" = "paramTopUpId"
$BODY$;

ALTER FUNCTION public.updatetopup(bigint, bigint, character varying, character varying, integer, integer, bigint)
    OWNER TO "OSB";
