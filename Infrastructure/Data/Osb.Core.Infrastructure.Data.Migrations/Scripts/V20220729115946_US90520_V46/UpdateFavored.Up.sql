CREATE OR REPLACE FUNCTION public.updatefavored(
	"paramFavoredId" bigint
)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."Favored"

SET "UpdateDate" = now()

WHERE 
	"FavoredId" = "paramFavoredId"
	AND "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.updatefavored(bigint)
   OWNER TO "OSB";
