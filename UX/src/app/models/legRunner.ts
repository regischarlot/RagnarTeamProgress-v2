export class LegRunner
{
    public id: number;
    public order: number;
    public van: number;
    public distance: number;
    public difficulty: number;

    public teamId: number;
    public legRunnerId: number;
    
    public runner1Id: number;
    public runner1Name: string;
    public runner1Pace: number;
    public runner1Cell: string;

    public runner2Id: number;
    public runner2Name: string;
    public runner2Pace: number;
    public runner2Cell: string;
    
    public pace: number;
    public truePace: string;

    public startTime: Date;
    public startTimeEstimated: boolean;
    public endTime: Date;
    public endTimeEstimated: boolean;

    public legTime: string;
    public legMap: string;
}



    