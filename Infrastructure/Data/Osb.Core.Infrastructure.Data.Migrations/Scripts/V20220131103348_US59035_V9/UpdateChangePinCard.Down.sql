DROP FUNCTION public.updatechangepincard(bigint, integer);

CREATE OR REPLACE FUNCTION public.updatechangepincard(
	"paramChangePinCardId" bigint,	
	"paramUpdateUserId" bigint,
	"paramStatus" integer,
	"paramAttempts" integer
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."ChangePinCard"
		SET
		   "Status" = "paramStatus",
		   "Attempts" = "paramAttempts",
		   "UpdateDate" = Now(),
		   "UpdateUserId" = "paramUpdateUserId"
		WHERE 
		   "DeletionDate" IS NULL 
		   AND "ChangePinCardId" = "paramChangePinCardId"
		   
$BODY$;

ALTER FUNCTION public.updatechangepincard(bigint, bigint, integer, integer)
    OWNER TO "OSB";