CREATE OR REPLACE FUNCTION public.insertuifunction(
	"paramName" character varying,
	"paramCode" bigint,
	"paramUserId" bigint)
    RETURNS TABLE("UIFunctionId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."UIFunction"
           (
	       	"Name",			
			"Code",
			"CreationDate",
			"UpdateDate",
			"CreationUserId",
			"UpdateUserId")
	VALUES (
			"paramName",
			"paramCode",
			now(),
			now(),
			"paramUserId",
			"paramUserId")RETURNING "UIFunctionId"
$BODY$;

ALTER FUNCTION public.insertuifunction(character varying, bigint, bigint)
    OWNER TO "OSB";