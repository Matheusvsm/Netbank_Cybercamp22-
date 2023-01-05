CREATE OR REPLACE FUNCTION public.updatenewaccount(
	"paramNewAccountId" bigint,
	"paramAttempts" integer,
	"paramStatus" integer,
	"paramUpdateUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."NewAccount"
    SET 
        "Status" = "paramStatus",
		"Attempts" = "paramAttempts",
		"UpdateUserId" = "paramUpdateUserId",
		"UpdateDate" = now()
    WHERE
        "NewAccountId" = "paramNewAccountId" AND
        "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.updatenewaccount(bigint, integer, integer, bigint)
    OWNER TO "OSB";
