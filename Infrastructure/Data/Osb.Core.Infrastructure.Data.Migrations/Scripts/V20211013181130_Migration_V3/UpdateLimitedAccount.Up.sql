CREATE OR REPLACE FUNCTION public.updatelimitedaccount(
	"paramLimitedAccountId" bigint,
	"paramAccountKey" character varying,
	"paramStatus" integer,
	"paramAttempts" integer,
	"paramUpdateUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."LimitedAccount"
	SET
		"AccountKey" = "paramAccountKey",
		"Status" = "paramStatus",
		"Attempts" = "paramAttempts",
		"UpdateUserId" = "paramUpdateUserId",
		"UpdateDate" = now()
	WHERE 
		"LimitedAccountId" = "paramLimitedAccountId" AND
		"DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.updatelimitedaccount(bigint, character varying, integer, integer, bigint)
    OWNER TO "OSB";