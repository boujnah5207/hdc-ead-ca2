<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="WindowsAzureCloud" generation="1" functional="0" release="0" Id="f7dd62d6-a3e4-45d3-b050-1ba5d264934e" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="WindowsAzureCloudGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="CA Mini Project V4:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/WindowsAzureCloud/WindowsAzureCloudGroup/LB:CA Mini Project V4:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="CA Mini Project V4:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/WindowsAzureCloud/WindowsAzureCloudGroup/MapCA Mini Project V4:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="CA Mini Project V4Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WindowsAzureCloud/WindowsAzureCloudGroup/MapCA Mini Project V4Instances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:CA Mini Project V4:Endpoint1">
          <toPorts>
            <inPortMoniker name="/WindowsAzureCloud/WindowsAzureCloudGroup/CA Mini Project V4/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapCA Mini Project V4:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/WindowsAzureCloud/WindowsAzureCloudGroup/CA Mini Project V4/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapCA Mini Project V4Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WindowsAzureCloud/WindowsAzureCloudGroup/CA Mini Project V4Instances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="CA Mini Project V4" generation="1" functional="0" release="0" software="G:\College Work\EAM\Term 2\CA2 Mini Project\Code Rebuild\CA Mini Project V4\WindowsAzureCloud\csx\Debug\roles\CA Mini Project V4" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;CA Mini Project V4&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;CA Mini Project V4&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WindowsAzureCloud/WindowsAzureCloudGroup/CA Mini Project V4Instances" />
            <sCSPolicyUpdateDomainMoniker name="/WindowsAzureCloud/WindowsAzureCloudGroup/CA Mini Project V4UpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/WindowsAzureCloud/WindowsAzureCloudGroup/CA Mini Project V4FaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="CA Mini Project V4UpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="CA Mini Project V4FaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="CA Mini Project V4Instances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="5b02ccea-d52f-4f29-b5cd-f7e2b6c9e3fb" ref="Microsoft.RedDog.Contract\ServiceContract\WindowsAzureCloudContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="dfc486b2-dbc1-4e43-81ae-3e03631f4da3" ref="Microsoft.RedDog.Contract\Interface\CA Mini Project V4:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/WindowsAzureCloud/WindowsAzureCloudGroup/CA Mini Project V4:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>