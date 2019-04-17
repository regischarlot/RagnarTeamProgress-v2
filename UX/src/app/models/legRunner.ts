import { JsonProperty } from './mapUtils';

export class LegRunner
{
    @JsonProperty('id')
    public id: number;
    @JsonProperty('order')
    public order: number;
    @JsonProperty('van')
    public van: number;
    @JsonProperty('distance')
    public distance: number;
    @JsonProperty('difficulty')
    public difficulty: number;

    @JsonProperty('teamId')
    public teamId: number;
    @JsonProperty('legRunnerId')
    public legRunnerId: number;
    
    @JsonProperty('runner1Id')
    public runner1Id: number;
    @JsonProperty('runner1Name')
    public runner1Name: string;
    @JsonProperty('runner1Pace')
    public runner1Pace: number;
    @JsonProperty('runner1Cell')
    public runner1Cell: string;

    @JsonProperty('runner2Id')
    public runner2Id: number;
    @JsonProperty('runner2Name')
    public runner2Name: string;
    @JsonProperty('runner2Pace')
    public runner2Pace: number;
    @JsonProperty('runner2Cell')
    public runner2Cell: string;
    
    @JsonProperty('pace')
    public pace: number;
    @JsonProperty('truePace')
    public truePace: string;

    @JsonProperty('startTime')
    public startTime: Date;
    @JsonProperty('startTimeEstimated')
    public startTimeEstimated: boolean;
    @JsonProperty('endTime')
    public endTime: Date;
    @JsonProperty('endTimeEstimated')
    public endTimeEstimated: boolean;

    @JsonProperty('legTime')
    public legTime: string;
    @JsonProperty('legMap')
    public legMap: string;
}



    