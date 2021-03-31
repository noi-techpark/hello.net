import * as React from 'react';
import { connect } from 'react-redux';

function Home(){
  const extHTML='<e-mobility-map-widget language="en" logo="https://www.greenmobility.bz.it/typo3conf/ext/interho/Resources/Public/Img/logo.png"></e-mobility-map-widget>'
  const [station,setStation] = React.useState<ODHStation>();
  interface ODHStation {
    pcode: string;
    pmetadata: {
      city?: string;
      state?: string;
      address?: string;
      capacity?: number;
      provider?: string;
      accessInfo?: string;
      accessType?: string;
      reservable?: boolean;
      paymentInfo?: string;
    };
    pcoordinate?:{
      x: number;
      y: number;
      srid?: number;
    }
  }
  React.useEffect(() => {
    fetchEmobilityData();
  },[]);
  const fetchEmobilityData = ():any =>{
    fetch("/emobility").then( async response => {
      setStation(await response.json());
    }); 
  }
  return (
  <div>
    <h1>Hello, world!</h1>
    {station ?
    <div>
      <h2>{station.pcode}</h2>
      {station.pcoordinate ?<div>{station.pcoordinate.x},{station.pcoordinate.y}</div>:<p>Coordinates are missing</p>}
    </div>
    :
    <h2>No station defined</h2>}
    <div style={{width:'100%',height:'300px'}} dangerouslySetInnerHTML={{__html:extHTML}}></div>
 </div>
);
}


export default connect()(Home);
