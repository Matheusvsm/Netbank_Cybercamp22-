DROP FUNCTION public.updateunblockcard(bigint, integer);

CREATE OR REPLACE FUNCTION public.updateunblockcard(
	"paramUnblockCardId" bigint,
	"paramStatus" integer,
	"paramAttempts" integer)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."UnblockCard"
              SET
                "Status" = "paramStatus",
				        "Attempts" = "paramAttempts",
                "UpdateDate" = now()
              WHERE
                "UnblockCardId" = "paramUnblockCardId"
$BODY$;

ALTER FUNCTION public.updateunblockcard(bigint, integer, integer)
    OWNER TO "OSB";