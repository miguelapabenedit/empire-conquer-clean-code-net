INSERT INTO "Guilds" ("Name","Description","CreatedBy","CreatedDate","UpdatedBy","UpdatedDate")
VALUES
('Guild Description Seed 1','Guild Seed 1','SEED USER',(SELECT GETUTCDATE()),'SEED USER',(SELECT GETUTCDATE())),
('Guild Description Seed 2','Guild Seed 2','SEED USER',(SELECT GETUTCDATE()),'SEED USER',(SELECT GETUTCDATE())),
('Guild Description Seed 3','Guild Seed 3','SEED USER',(SELECT GETUTCDATE()),'SEED USER',(SELECT GETUTCDATE()))