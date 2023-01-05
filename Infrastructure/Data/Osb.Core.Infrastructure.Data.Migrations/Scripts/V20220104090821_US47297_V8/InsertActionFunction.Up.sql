CREATE OR REPLACE FUNCTION public.insertactionfunction(
	"paramAction" character varying,
	"paramController" character varying,
	"paramUserId" bigint)
    RETURNS TABLE("ActionFunctionId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."ActionFunction"
           (
	       	"Action",			
			"Controller",
			"CreationDate",
			"UpdateDate",
			"CreationUserId",
			"UpdateUserId")
	VALUES (
		   "paramAction",
		   "paramController",
		   now(),
			now(),
			"paramUserId",
		   "paramUserId") RETURNING "ActionFunctionId"
$BODY$;

ALTER FUNCTION public.insertactionfunction(character varying, character varying, bigint)
    OWNER TO "OSB";