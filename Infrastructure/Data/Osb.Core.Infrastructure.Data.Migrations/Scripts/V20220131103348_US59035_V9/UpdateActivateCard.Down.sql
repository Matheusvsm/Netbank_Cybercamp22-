DROP FUNCTION public.updateactivatecard(bigint, integer);

CREATE OR REPLACE FUNCTION public.updateactivatecard(
	"paramActivateCardId" bigint,
	"paramStatus" integer,
	"paramAttempts" integer,
	"paramUpdateUserId" bigint
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."ActivateCard"
			  SET
                "Status" = "paramStatus",
				"Attempts" = "paramAttempts",
				"UpdateUserId" = "paramUpdateUserId",
                "UpdateDate" = now()				
		 	  WHERE 
	            "ActivateCardId" = "paramActivateCardId"
$BODY$;

ALTER FUNCTION public.updateactivatecard(bigint, integer, integer, bigint)
    OWNER TO "OSB";