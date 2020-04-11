delete from dbo.Vehicle_Years;
delete from dbo.Vehicle_Makes;
delete from dbo.Vehicle_Models;
delete from dbo.Vehicle_Safetyratings;



insert into dbo.Vehicle_Years
select 
ModelYear
from dbo.years where ModelYear not in (select ModelYear from dbo.Vehicle_Years);


insert into dbo.Vehicle_Makes
select 
distinct Make
from dbo.makes where Make not in (select Make from dbo.Vehicle_Makes);
;

insert into dbo.Vehicle_Models
select 
Distinct Model
from dbo.models where Model not in (select Model from dbo.Vehicle_Models);
;

insert into dbo.Vehicle_Safetyratings
select 
VehicleId,
VehicleDescription,
OverallRating,
OverallFrontCrashRating,
FrontCrashDriversideRating,
FrontCrashPassengersideRating,
OverallSideCrashRating,
SideCrashDriversideRating,
SideCrashPassengersideRating,
RolloverRating,
RolloverPossibility,
SidePoleCrashRating,
ComplaintsCount,
RecallsCount,
y.year_id,
m.make_id,
md.model_id
from dbo.safety s
left join dbo.Vehicle_Years y
on s.ModelYear=y.ModelYear
left join dbo.Vehicle_Makes m
on s.Make=m.Make
left join dbo.Vehicle_Models md
on s.Model=md.Model
where vehicleid not in (select vehicleid from dbo.Vehicle_Safetyratings);

