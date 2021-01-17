# candidatematcher
This is a small Blazor application that demonstrated how to initiate requests to an external api..

Solution contains:

* Client UI to display jobs, candidates, best matched candidates, best matched jobs for candidate
* Context menu on jobs and candidates
* Session storage for Blazor
* Services for hitting external apis
* Dependency injection with custom service classes
* External api uri in appsettings.json

Assumptions
* Best matched candidates are based on the number of distinct skills required for the job against the candidate skills.
* Best matched jobs are based on the number of distinct skills of the candidate skills against the job skills requirement.
* Number of top matches to return is in appsettings.json "TopCandidates"

How to run
* Download and unzip to local
* Open solution  in Visual Studio 2019
* Build and run

![Alt text](https://github.com/hph138/candidatematcher/blob/main/screenshots/home.PNG "Home")
![Alt text](https://github.com/hph138/candidatematcher/blob/main/screenshots/jobs.PNG "Jobs")
![Alt text](https://github.com/hph138/candidatematcher/blob/main/screenshots/candidates.PNG "Candidates")
![Alt text](https://github.com/hph138/candidatematcher/blob/main/screenshots/jobscontextmenu.png "Jobs context menu")
![Alt text](https://github.com/hph138/candidatematcher/blob/main/screenshots/cancontextmenu.png "Candidates context menu")
![Alt text](https://github.com/hph138/candidatematcher/blob/main/screenshots/bestmatchcandidate.PNG "Top 10 candidates for job")
