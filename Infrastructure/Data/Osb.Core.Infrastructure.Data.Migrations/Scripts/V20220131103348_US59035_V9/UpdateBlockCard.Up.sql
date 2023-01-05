DROP FUNCTION public.updateblockcard(bigint, integer, integer);

CREATE OR REPLACE FUNCTION public.updateblockcard(
	"paramBlockCardId" bigint,
	"paramStatus" integer
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."BlockCard"
              SET
                "Status" = "paramStatus",				
                "UpdateDate" = now()
              WHERE
                "BlockCardId" = "paramBlockCardId"
$BODY$;

ALTER FUNCTION public.updateblockcard(bigint, integer)
    OWNER TO "OSB";