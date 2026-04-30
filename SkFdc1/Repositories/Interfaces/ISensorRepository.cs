using SkFdc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//데이터에 접근하는 규칙명세
namespace SkFdc1.Repositories.Interfaces
{        
    public interface ISensorRepository
    {
        //센서리스트
        Task<List<SensorDto>> GetSensorsAsync();
        //한개의 센서정보
        Task<SensorDto> GetSensorOneAsync(string sensorId);
        //lot별, 타입별 센서데이터값들
        Task<List<SensorValuesDto>> GetSensorValuesAsync(string lotId, string sensorType);
        //센서타입
        Task<List<SensorTypeDto>> GetSensorTypeAsync();
    }
    //여러개의 인터페이스 보다 한개의 인터페이스안에 관련 메소드를 전부 넣는게 좋다
    //public interface ISensorOneRepository
    //{
    //    Task<SensorDto> GetSensorOneAsync();
    //}    
}
