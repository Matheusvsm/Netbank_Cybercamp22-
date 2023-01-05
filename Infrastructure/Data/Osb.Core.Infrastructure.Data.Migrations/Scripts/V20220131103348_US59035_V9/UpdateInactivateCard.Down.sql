DROP FUNCTION public.updateinactivatecard(bigint, integer);

CREATE OR REPLACE FUNCTION public.updateinactivatecard(
	"paramInactivateCardId" bigint,
	"paramStatus" integer,
	"paramAttempts" integer,
	"paramUpdateUserId" bigint
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."InactivateCard"
			  SET
                "Status" = "paramStatus",
				"Attempts" = "paramAttempts",
				"UpdateUserId" = "paramUpdateUserId",
                "UpdateDate" = now()
		 	  WHERE 
	            "InactivateCardId" = "paramInactivateCardId"
$BODY$;

ALTER FUNCTION public.updateinactivatecard(bigint, integer, integer, bigint)
    OWNER TO "OSB";

