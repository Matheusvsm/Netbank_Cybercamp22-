CREATE OR REPLACE FUNCTION public.insertexceptionlog(
	"paramMessage" character varying,
	"paramExceptionType" integer,
	"paramUserId" bigint
)
    RETURNS void 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE

AS $BODY$
INSERT INTO public."ExceptionLog"
	(
	"Message",
	"ExceptionType",
	"CreationDate",    
    "UpdateDate",
    "CreationUserId",
    "UpdateUserId"
	)
	VALUES
	(
	"paramMessage",
	"paramExceptionType",	
	now(),    
    now(),
    "paramUserId",
	"paramUserId"
	)
$BODY$;

ALTER FUNCTION public.insertexceptionlog(character varying, integer, bigint)
    OWNER TO "OSB";